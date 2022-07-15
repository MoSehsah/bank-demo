package com.vmware.tanzu.web.service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;

import com.vmware.tanzu.web.domain.CompanyInfo;
import com.vmware.tanzu.web.domain.Order;
import com.vmware.tanzu.web.domain.Portfolio;
import com.vmware.tanzu.web.domain.Quote;
import com.vmware.tanzu.web.exception.OrderNotSavedException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.cloud.context.config.annotation.RefreshScope;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.cloud.client.discovery.DiscoveryClient;

//import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;


@Service
@RefreshScope
public class QuotesService {
	private static final Logger logger = LoggerFactory
			.getLogger(QuotesService.class);
	@Autowired
	//@LoadBalanced
	private RestTemplate restTemplate;

	@Autowired
    private DiscoveryClient discoveryClient;

	@Value("${EUREKA_URL:noEureka}")
	protected String eurekaUrl;

	@Value("${DEP_NS:dev}")
	protected String depNs;

	@Value("${vmware.tanzu.downstream-protocol:http}")
	protected String downstreamProtocol;

	@Value("${quoteServiceName:quote-svc}")
	private String quotesService;
	
	// The below is commented out to demonstrate impact of lack of hystrix, and can be uncommented during presentation
	//@HystrixCommand(fallbackMethod = "getQuoteFallback")
	public Quote getQuote(String symbol) {
		logger.debug("Fetching quote: " + symbol);
		List<Quote> quotes = getMultipleQuotes(symbol);
		if (quotes.size() == 1 ) {
			logger.debug("Fetched quote: " + quotes.get(0));
			return quotes.get(0);
		}
		logger.debug("exception: should only be 1 quote and got multiple or zero: " + quotes.size());
		return new Quote();
	}
	
	private Quote getQuoteFallback(String symbol) {
		logger.debug("Fetching fallback quote for: " + symbol);
		Quote quote = new Quote();
		quote.setSymbol(symbol);
		quote.setStatus("FAILED");
		return quote;
	}
	// The below is commented out to demonstrate impact of lack of hystrix, and can be uncommented during presentation
	//@HystrixCommand(fallbackMethod = "getCompaniesFallback")
	public List<CompanyInfo> getCompanies(String name) {
		logger.debug("Fetching companies with name or symbol matching: " + name);
		String quoteServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("quote-service").get(0).getScheme()+"://"+discoveryClient.getInstances("quote-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		String externalQuoteServiceURI = downstreamProtocol + "://"+ quotesService;
		String quoteServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": quoteServiceURI = externalQuoteServiceURI;
					break;
			default: quoteServiceURI = quoteServiceDiscoveredURI;
					break;
		}
		CompanyInfo[] infos = restTemplate.getForObject(quoteServiceURI + "/v1/quotes?q={name}", CompanyInfo[].class, name);
		return Arrays.asList(infos);
	}
	private List<CompanyInfo> getCompaniesFallback(String name) {
		List<CompanyInfo> infos = new ArrayList<>();
		return infos;
	}
	/**
	 * Retrieve multiple quotes.
	 * 
	 * @param symbols comma separated list of symbols.
	 * @return
	 */
	public List<Quote> getMultipleQuotes(String symbols) {
		logger.debug("retrieving multiple quotes: " + symbols);
		String quoteServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("quote-service").get(0).getScheme()+"://"+discoveryClient.getInstances("quote-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		String externalQuoteServiceURI = downstreamProtocol + "://"+ quotesService;
		String quoteServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": quoteServiceURI = externalQuoteServiceURI;
					break;
			default: quoteServiceURI = quoteServiceDiscoveredURI;
					break;
		}
		Quote[] quotesArr = restTemplate.getForObject(quoteServiceURI + "/v1/quotes?q={symbols}", Quote[].class, symbols);
		List<Quote> quotes = Arrays.asList(quotesArr);
		logger.debug("Received quotes: {}",quotes);
		return quotes;
		
	}
	/**
	 * Retrieve multiple quotes.
	 * 
	 * @param symbols
	 * @return
	 */
	public List<Quote> getMultipleQuotes(String[] symbols) {
		logger.debug("Fetching multiple quotes array: {} ",Arrays.asList(symbols));
		
		return getMultipleQuotes(Arrays.asList(symbols));
	}
	/**
	 * Retrieve multiple quotes.
	 * 
	 * @param symbols
	 * @return
	 */
	public List<Quote> getMultipleQuotes(Collection<String> symbols) {
		logger.debug("Fetching multiple quotes array: {} ",symbols);
		StringBuilder builder = new StringBuilder();
		for (Iterator<String> i = symbols.iterator(); i.hasNext();) {
			builder.append(i.next());
			if (i.hasNext()) {
				builder.append(",");
			}
		}
		return getMultipleQuotes(builder.toString());
	}

}
