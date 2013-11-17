@echo off
wsdl stocks.wsdl /n:NewsWebservice /out:..\src\NewsWebservice\StockService.cs /urlkey:stocks /nologo 
wsdl news.wsdl /n:News.FormApp.Services /out:..\src\NewsFormApp\Services\NewsService.cs /urlkey:news /nologo 