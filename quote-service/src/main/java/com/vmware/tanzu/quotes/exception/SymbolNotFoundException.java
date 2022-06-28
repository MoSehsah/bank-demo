package com.vmware.tanzu.quotes.exception;

/**
 * Exception representing that a quote symbol cannot be found.
 * @author David Ferreira Pinto
 *
 */
public class SymbolNotFoundException extends Exception {

	public SymbolNotFoundException(String message ) {
		super(message);
	}
}
