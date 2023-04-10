package com.vmware.tanzu.quotes.service;

// import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
// import com.netflix.hystrix.contrib.javanica.annotation.HystrixProperty;
import com.vmware.tanzu.quotes.exception.SymbolNotFoundException;

import com.vmware.tanzu.quotes.domain.*;

import lombok.extern.java.Log;
import lombok.extern.slf4j.Slf4j;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.cloud.client.circuitbreaker.CircuitBreakerFactory;
// import org.springframework.cloud.client.circuitbreaker.CircuitBreakerFactory;
// import org.springframework.cloud.context.config.annotation.RefreshScope;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.stream.Collectors;

/**
 * A service to retrieve Company and Quote information.
 * 
 * @author David Ferreira Pinto
 *
 */
@Service
// @RefreshScope
@Slf4j
public class QuoteService {

	@Value("${vmware.tanzu.quote.quote_url}")
	protected String quote_url;

	@Value("${vmware.tanzu.quote.quotes_url}")
	protected String quotes_url;

	
	@Value("${vmware.tanzu.quote.iex.token}")
	protected String token;

	@Autowired
	private CircuitBreakerFactory cbFactory;

	// @Value("${pivotal.quotes.companies_url}")
	// protected String company_url;

	public static final String FMT = "json";

	/*
	 * cannot autowire as don't want ribbon here.
	 */
	private RestTemplate restTemplate = new RestTemplate();

	/**
	 * Retrieves an up to date quote for the given symbol.
	 * 
	 * @param symbol
	 *               The symbol to retrieve the quote for.
	 * @return The quote object or null if not found.
	 * @throws SymbolNotFoundException
	 */
	@Cacheable(value = "quotes", key = "#symbol")
	public Quote getQuote(String symbol) throws SymbolNotFoundException {
		if (Boolean.valueOf(System.getenv("AIRGAPPED"))) {
			log.debug("AIRGAPPED environment variable is set, returning specific value");
			List<Quote> quotes = new ArrayList<>();
			Quote quote = new Quote();
			quote.setSymbol("VMW");
			quote.setName("Vmware Inc. - Class A");
			quote.setLastPrice(new BigDecimal("123.94"));
			quote.setChange(new BigDecimal("-1.07"));
			quote.setChangeYTD(null);
			quote.setChangePercentYTD(null);
			quote.setHigh(null);
			quote.setLow(null);
			quote.setOpen(null);
			quote.setCurrency("USD");
			quote.setStatus("SUCCESS");
			quote.setChangePercent(new BigDecimal("-0.00371").floatValue());
			quote.setTimestamp(Date.from(LocalDateTime.parse("Mon Apr 03 20:00:00 UTC 2023", DateTimeFormatter.ofPattern("EEE MMM dd HH:mm:ss zzz yyyy")).atZone(ZoneId.of("UTC")).toInstant()));
			quote.setmSDate((float) 0L);
			quote.setMarketCap((float) 53106230000L);
			quote.setVolume(1274700);
			quotes.add(quote);
			return quote;
		}
		log.debug("QuoteService.getQuote: retrieving quote for: " + symbol);

		Map<String, String> params = new HashMap<String, String>();
		params.put("symbol", symbol);
		params.put("token", token);

		IexQuote quote =  cbFactory.create("quote").run(() -> restTemplate.getForObject(quote_url, IexQuote.class, params), throwable -> getQuoteFallback(symbol));

		if (quote.getSymbol() == null) {
			throw new SymbolNotFoundException("Symbol not found: " + symbol);
		}

		log.debug("QuoteService.getQuote: retrieved quote: " + quote);

		return QuoteMapper.INSTANCE.mapFromIexQuote(quote);

	}

	/**
	 * Retrieve multiple quotes at once.
	 * 
	 * @param symbols
	 *            comma delimeted list of symbols.
	 * @return a list of quotes.
	 */
	@Cacheable(value = "quotes", key = "#symbols")
	public List<Quote> getQuotes(String symbols) {
		if (Boolean.valueOf(System.getenv("AIRGAPPED"))) {
			log.debug("AIRGAPPED environment variable is set, returning specific value");
			List<Quote> quotes = new ArrayList<>();
			Quote quote = new Quote();
			quote.setSymbol("VMW");
			quote.setName("Vmware Inc. - Class A");
			quote.setLastPrice(new BigDecimal("123.94"));
			quote.setChange(new BigDecimal("-1.07"));
			quote.setChangeYTD(null);
			quote.setChangePercentYTD(null);
			quote.setHigh(null);
			quote.setLow(null);
			quote.setOpen(null);
			quote.setCurrency("USD");
			quote.setStatus("SUCCESS");
			quote.setChangePercent(new BigDecimal("-0.00371").floatValue());
			quote.setTimestamp(Date.from(LocalDateTime.parse("Mon Apr 03 20:00:00 UTC 2023", DateTimeFormatter.ofPattern("EEE MMM dd HH:mm:ss zzz yyyy")).atZone(ZoneId.of("UTC")).toInstant()));
			quote.setmSDate((float) 0L);
			quote.setMarketCap((float) 53106230000L);
			quote.setVolume(1274700);
			quotes.add(quote);
			return quotes;
		}
		
		
		log.debug("retrieving multiple quotes for: " + symbols);
		Map<String, String> params = new HashMap<String, String>();
		params.put("token", token);
		params.put("symbols", symbols);
		IexBatchQuote batchQuotes = restTemplate.getForObject(quotes_url, IexBatchQuote.class, params);

		log.debug("Got response: " + batchQuotes);
		final List<Quote> quotes = new ArrayList<>();

		Arrays.asList(symbols.split(",")).forEach(symbol -> {
			if(batchQuotes.containsKey(symbol)) {
				quotes.add(QuoteMapper.INSTANCE.mapFromIexQuote(batchQuotes.get(symbol).get("quote")));
			} else {
				log.warn("Quote could not be found for the following symbol: " + symbol);
				Quote quote = new Quote();
				quote.setSymbol(symbol);
				quote.setStatus("FAILED");
				quotes.add(quote);
			}
		});

		return quotes;
	}

	@SuppressWarnings("unused")
	private IexQuote getQuoteFallback(String symbol){
		log.debug("QuoteService.getQuoteFallback: circuit opened for symbol: "
				+ symbol);
		IexQuote quote = new IexQuote();
		quote.setSymbol(null);
		return quote;
	}

	

}
