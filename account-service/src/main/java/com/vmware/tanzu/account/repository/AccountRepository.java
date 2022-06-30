package com.vmware.tanzu.account.repository;

import java.util.List;

import org.springframework.data.repository.CrudRepository;

import com.vmware.tanzu.account.domain.Account;
import com.vmware.tanzu.account.domain.AccountType;

public interface AccountRepository extends CrudRepository<Account,Integer> {
	public List<Account> findByUserid(String userId);
	public List<Account> findByUseridAndType(String userId, AccountType type);
}
