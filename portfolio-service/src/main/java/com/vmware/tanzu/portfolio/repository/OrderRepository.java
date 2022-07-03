package com.vmware.tanzu.portfolio.repository;


import java.util.List;

import com.vmware.tanzu.portfolio.domain.Order;

import org.springframework.data.repository.CrudRepository;
/**
 * 
 * @author David Ferreira Pinto
 *
 */
public interface OrderRepository extends CrudRepository<Order,Integer> {

	List<Order> findByUserId(String userId);
}
