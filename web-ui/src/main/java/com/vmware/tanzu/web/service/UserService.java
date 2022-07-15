package com.vmware.tanzu.web.service;

import java.util.Map;

import com.vmware.tanzu.web.domain.AuthenticationRequest;
import com.vmware.tanzu.web.domain.User;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.cloud.context.config.annotation.RefreshScope;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.cloud.client.ServiceInstance;
import org.springframework.cloud.client.discovery.DiscoveryClient;

@Service
@RefreshScope
public class UserService {
	private static final Logger logger = LoggerFactory
			.getLogger(UserService.class);
	
	@Autowired
	//@LoadBalanced
	private RestTemplate restTemplate;

	@Autowired
    private DiscoveryClient discoveryClient;

	@Value("${EUREKA_URL:noEureka}")
	protected String eurekaUrl;
	
	@Value("${DEP_NS:dev}")
	protected String depNs;
	
	@Value("${userServiceName:user-svc}")
	private String userService;

	@Value("${vmware.tanzu.downstream-protocol:http}")
	protected String downstreamProtocol;

	public void createUser(User user) {
		logger.debug("Creating user with userId: " + user.getUserid());
		logger.debug(user.toString());
		String userServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getScheme()+"://"+discoveryClient.getInstances("user-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		logger.info("++++++++++++++"+userServiceDiscoveredURI);
		String externalUserServiceURI = downstreamProtocol + "://"+ userService;
		String userServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": userServiceURI = externalUserServiceURI;
					break;
			default: userServiceURI = userServiceDiscoveredURI;
					break;
		}
		//String status = restTemplate.postForObject(downstreamProtocol + "://" + userService + "/users/", user, String.class);
		String status = restTemplate.postForObject(userServiceURI + "/users/", user, String.class);
		logger.info("Status from registering account for "+ user.getUserid()+ " is " + status);
	}
	
	public Map<String,Object> login(AuthenticationRequest request){
		logger.debug("logging in with userId:" + request.getUsername());
		@SuppressWarnings("unchecked")
		String userServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getScheme()+"://"+discoveryClient.getInstances("user-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		String externalUserServiceURI = downstreamProtocol + "://"+ userService;
		String userServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": userServiceURI = externalUserServiceURI;
					break;
			default: userServiceURI = userServiceDiscoveredURI;
					break;
		}
		//Map<String,Object> result = (Map<String, Object>) restTemplate.postForObject(downstreamProtocol + "://" + userService + "/login/".toString(), request, Map.class);
		Map<String,Object> result = (Map<String, Object>) restTemplate.postForObject(userServiceURI + "/login/".toString(), request, Map.class);
		return result;
	}
	
	public User getUser(String user) {
		logger.debug("Looking for user with user name: " + user);
		String userServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getScheme()+"://"+discoveryClient.getInstances("user-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		String externalUserServiceURI = downstreamProtocol + "://"+ userService;
		String userServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": userServiceURI = externalUserServiceURI;
					break;
			default: userServiceURI = userServiceDiscoveredURI;
					break;
		}
	    User account = restTemplate.getForObject(userServiceURI + "/users/{user}", User.class, user);
		//User account = restTemplate.getForObject(downstreamProtocol + "://" + userService + "/users/{user}", User.class, user);
	    logger.debug("Got user: " + account);
	    return account;
	}
	
	public void logout(String user) {
		logger.debug("logging out user with userId: " + user);
		String userServiceDiscoveredURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getScheme()+"://"+discoveryClient.getInstances("user-service").get(0).getServiceId().toLowerCase()+"."+depNs+".svc.cluster.local");
		String externalUserServiceURI = downstreamProtocol + "://"+ userService;
		String userServiceURI = null;

		switch (eurekaUrl)
		{
			case "noEureka": userServiceURI = externalUserServiceURI;
					break;
			default: userServiceURI = userServiceDiscoveredURI;
					break;
		}
	    ResponseEntity<?> response = restTemplate.getForEntity(userServiceURI + "/logout/{user}", String.class, user);
		//ResponseEntity<?> response = restTemplate.getForEntity(downstreamProtocol + "://" + userService + "/logout/{user}", String.class, user);
	    logger.debug("Logout response: " + response.getStatusCode());
	}
	
}
