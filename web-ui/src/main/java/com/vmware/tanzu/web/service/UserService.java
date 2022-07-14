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
	
	@Value("${userServiceName:user-svc}")
	private String userService;

	@Value("${vmware.tanzu.downstream-protocol:http}")
	protected String downstreamProtocol;

	public void createUser(User user) {
		logger.debug("Creating user with userId: " + user.getUserid());
		logger.debug(user.toString());
		String userServiceURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getUri());
		//String status = restTemplate.postForObject(downstreamProtocol + "://" + userService + "/users/", user, String.class);
		String status = restTemplate.postForObject(userServiceURI + "/users/", user, String.class);
		logger.info("Status from registering account for "+ user.getUserid()+ " is " + status);
	}
	
	public Map<String,Object> login(AuthenticationRequest request){
		logger.debug("logging in with userId:" + request.getUsername());
		@SuppressWarnings("unchecked")
		String userServiceURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getUri());
		//Map<String,Object> result = (Map<String, Object>) restTemplate.postForObject(downstreamProtocol + "://" + userService + "/login/".toString(), request, Map.class);
		Map<String,Object> result = (Map<String, Object>) restTemplate.postForObject(userServiceURI + "/login/".toString(), request, Map.class);
		return result;
	}
	
	public User getUser(String user) {
		logger.debug("Looking for user with user name: " + user);
		String userServiceURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getUri());
	    User account = restTemplate.getForObject(userServiceURI + "/users/{user}", User.class, user);
		//User account = restTemplate.getForObject(downstreamProtocol + "://" + userService + "/users/{user}", User.class, user);
	    logger.debug("Got user: " + account);
	    return account;
	}
	
	public void logout(String user) {
		logger.debug("logging out user with userId: " + user);
		String userServiceURI = String.valueOf(discoveryClient.getInstances("user-service").get(0).getUri());
	    ResponseEntity<?> response = restTemplate.getForEntity(userServiceURI + "/logout/{user}", String.class, user);
		//ResponseEntity<?> response = restTemplate.getForEntity(downstreamProtocol + "://" + userService + "/logout/{user}", String.class, user);
	    logger.debug("Logout response: " + response.getStatusCode());
	}
	
}
