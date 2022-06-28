package com.vmware.tanzu.quotes.domain;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Data;

import java.math.BigDecimal;

@JsonIgnoreProperties(ignoreUnknown = true)
@Data
public class IexQuote {

    private String symbol;
    private String companyName;
    private BigDecimal open;
    private BigDecimal close;
    private Long closeTime;
    private BigDecimal high;
    private BigDecimal low;
    private BigDecimal latestPrice;
    private Long latestUpdate;
    private String latestSource;
    private BigDecimal change;
    private BigDecimal changePercent;
    private BigDecimal avgTotalVolume;
    private BigDecimal marketCap;

}
