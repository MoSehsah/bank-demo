package com.vmware.tanzu.web.controller;

import javax.servlet.http.HttpServletRequest;

import com.vmware.tanzu.web.domain.Order;
import com.vmware.tanzu.web.domain.Search;
import com.vmware.tanzu.web.service.AccountService;
import com.vmware.tanzu.web.service.PortfolioService;
import com.vmware.tanzu.web.service.QuotesService;
import com.vmware.tanzu.web.service.MarketSummaryService;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AnonymousAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.client.HttpServerErrorException;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class PortfolioController {
	private static final Logger logger = LoggerFactory
			.getLogger(PortfolioController.class);
	
	@Autowired
	private PortfolioService portfolioService;
	
	@Autowired
	private MarketSummaryService summaryService;
	
	@Autowired
	private AccountService accountService;
	
	@RequestMapping(value = "/portfolio", method = RequestMethod.GET)
	public String portfolio(Model model) {
		logger.debug("/portfolio");
		model.addAttribute("marketSummary", summaryService.getMarketSummary());
		
		//check if user is logged in!
		Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
		if (!(authentication instanceof AnonymousAuthenticationToken)) {
		    String currentUserName = authentication.getName();
		    logger.debug("portfolio: User logged in: " + currentUserName);
		    
		    //TODO: add account summary.
		    try {
		    	model.addAttribute("portfolio",portfolioService.getPortfolio(currentUserName));
		    	model.addAttribute("accounts",accountService.getAccounts(currentUserName));
		    } catch (HttpServerErrorException e) {
		    	logger.debug("error retrieving portfolfio: " + e.getMessage());
		    	model.addAttribute("portfolioRetrievalError",e.getMessage());
		    }
		    model.addAttribute("order", new Order());
		}
		
		return "portfolio";
	}

	@ExceptionHandler({ Exception.class })
	public ModelAndView error(HttpServletRequest req, Exception exception) {
		logger.debug("Handling error: " + exception);
		logger.warn("Exception: ", exception);
		ModelAndView model = new ModelAndView();
		model.addObject("errorCode", exception.getMessage());
		model.addObject("errorMessage", exception);
		model.setViewName("error");
		return model;
	}

}
