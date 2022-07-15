package com.vmware.tanzu.web.service;

//import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
import com.vmware.tanzu.web.domain.Quote;
import com.vmware.tanzu.web.domain.Trade;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.cloud.context.config.annotation.RefreshScope;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.cloud.client.discovery.DiscoveryClient;

import java.util.*;


@Service
@RefreshScope
public class AnalyticsService {
	private static final Logger logger = LoggerFactory
			.getLogger(AnalyticsService.class);

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

	@Value("${analyticsServiceName:analytics-svc}")
	private String analyticsService;
	
	// The below is commented out to demonstrate impact of lack of hystrix, and can be uncommented during presentation
	//@HystrixCommand(fallbackMethod = "getAnalyticsFallback")
	public List<Trade> getTrades(String symbol) {
		logger.debug("Fetching trades: " + symbol);

		String analyticsServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("analytics-service").get(0).getScheme()+"://"+discoveryClient.getInstances("analytics-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		String externalAnalyticsServiceURI = downstreamProtocol + "://"+ analyticsService;
		String analyticsServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": analyticsServiceURI = externalAnalyticsServiceURI;
					break;
			default: analyticsServiceURI = analyticsServiceDiscoveredURI;
					break;
		}
		Trade[] tradesArr = restTemplate.getForObject(analyticsServiceURI + "/analytics/trades/{symbol}", Trade[].class, symbol);
		List<Trade> trades = Arrays.asList(tradesArr);
		logger.debug("Found " + trades.size() + " trades");
		return trades;
	}
	
	private List<Trade> getAnalyticsFallback(String symbol) {
		logger.warn("Falling back due to error.");

		return new ArrayList<Trade>();
	}

}
