package com.vmware.tanzu.user.repository;

import org.springframework.data.repository.CrudRepository;

import com.vmware.tanzu.user.domain.User;

public interface UserRepository extends CrudRepository<User,Integer> {
	public User findByUseridAndPasswd(String userId, String passwd);
	public User findByUserid(String userId);
	public User findByAuthtoken(String authtoken);
}
