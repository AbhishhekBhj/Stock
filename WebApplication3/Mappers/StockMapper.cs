﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication3.DTOs.Stocks;
using WebApplication3.Models;

namespace WebApplication3.Mappers
{

    //this mapper class will be used to map the api data to a suitable format
    public static class StockMapper
    {

        public static StockDTO ToStockDTO(this Stock stock)
        {
            //into a map 


            //return a new Stockdto object
            return new StockDTO{

                StockId = stock.StockId,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                LastDiv = stock.LastDiv
                ,    MarketCap = stock.MarketCap,
                PurchasePrice = stock.PurchasePrice,
                Symbol = stock.Symbol,
                
                Comments  = stock.Comments.Select(e=>e.ToCommentDTO()).ToList()


            };

        }

        public static Stock ToPostStockDTO(this PostStockDTO stock)
        {
            return new Stock { 
            
                CompanyName=stock.CompanyName,
                

                Industry =stock.Industry,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                
                PurchasePrice=stock.PurchasePrice,
                Symbol = stock.Symbol
            
            };
        }
    }
}
