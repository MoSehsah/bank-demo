
using System;

public class CompanyMapper {
    public static CompanyMapper INSTANCE = new CompanyMapper();

    private CompanyMapper() :base(){
    }

    public CompanyInfo mapFromIexQuote(IexQuote iexQuote) {
        if (iexQuote == null) {
            return null;
        }

        CompanyInfo mappedCompany = new CompanyInfo();
        mappedCompany.Symbol = iexQuote.symbol;
        mappedCompany.Name = iexQuote.companyName;
        mappedCompany.Exchange = "NASDAQ";
        return mappedCompany;
    }

}
