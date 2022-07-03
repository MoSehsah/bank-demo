package com.vmware.tanzu.portfolio.service;


import brave.ScopedSpan;
import brave.Span;
import brave.Tracer;
import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
import com.vmware.tanzu.portfolio.domain.Order;
import com.vmware.tanzu.portfolio.repository.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PortfolioRepositoryService {

    private Tracer tracer;
    private OrderRepository repository;

    @Autowired
    public PortfolioRepositoryService(Tracer tracer, OrderRepository repository) {
        this.tracer = tracer;
        this.repository = repository;
    }

    @HystrixCommand(
            commandKey = "portfolio-service.getOrderFromDB",
            groupKey = "portfolio-service.getOrderFromDB",
            threadPoolKey = "portfolio-service.getOrderFromDB")
    List<Order> getOrders(String userId) {

        Span newSpan = this.tracer.nextSpan().name("retrieveUserId");

        List<Order> orders = repository.findByUserId(userId);
        try{
            return repository.findByUserId(userId);
        } finally {
            newSpan.finish();
        }
    }

}
