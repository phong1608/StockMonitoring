# 📈 Stock Monitoring Realtime System

## Overview
A real-time stock price monitoring platform focused on **tracking**, **visualization**, and **performance**, without trading functionality. Built to demonstrate **Clean Architecture**, **CQRS**, and **realtime system design**.

---

## Key Features
- Realtime stock price updates via **SignalR (WebSocket)**
- Live price charts (minute-based data)
- Watchlist: follow / unfollow stock symbols
- Redis caching for high-performance reads
- External market data integration (**Finnhub API**)
  
## Architecture
API → Application → Domain → Infrastructure
- **Domain**: Core entities (Stock, StockPriceHistory)
- **Application**: CQRS, business logic, interfaces
- **Infrastructure**: EF Core, Redis, SignalR, external APIs
- **API**: Controllers
  
## Tech Stack
- ASP.NET Core Web API
- SignalR (WebSocket)
- SQL Server + EF Core
- Redis
- Finnhub Stock API
