package com.vmware.tanzu.quotes.service;

// import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
// import com.netflix.hystrix.contrib.javanica.annotation.HystrixProperty;
import com.vmware.tanzu.quotes.exception.SymbolNotFoundException;

import com.vmware.tanzu.quotes.domain.*;

import lombok.extern.java.Log;
import lombok.extern.slf4j.Slf4j;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.client.circuitbreaker.CircuitBreakerFactory;
// import org.springframework.cloud.client.circuitbreaker.CircuitBreakerFactory;
// import org.springframework.cloud.context.config.annotation.RefreshScope;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

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
	public Quote getQuote(String symbol) throws SymbolNotFoundException {

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
	public List<Quote> getQuotes(String symbols) {
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
