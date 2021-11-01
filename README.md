# RealEstateScraper

This is assessment project.

The goal of the project is build application which can grap data from public API and analyze it.

## Project layout
Project built on Onion Architecture.

The project has the following layout:
- Assessment.Res.Core.Contracts - Domain entities and interfaces for Core project and Infrastructure projects. 
- Assessment.Res.Core - Domain services.
- Assessment.Res.Application.Contracts - application entities and interfaces.
- Assessment.Res.Application - Application logic.
- Assessment.Res.Infrastructure.Database - EF and repositories.
- Assessment.Res.Infrastructure.ThirdPartyApis - Service to work with Funda API.
- Assessment.Res.App - console application builded on Topshelf.

## Notes
- To create database you need to run the commands Update-Database.

## Results
### Top 10 agents

Name / Id / Number Of Properties
- Broersma Makelaardij / 24067 / 81
- Hallie & Van Klooster Makelaardij / 24605 / 66
- Ramón Mossel Makelaardij o.g. B.V. / 24592 / 59
- Carla van den Brink B.V. / 24065 / 56
- Eefje Voogd Makelaardij / 24705 / 56
- Makelaardij Van der Linden Amsterdam / 24079 / 55
- Kijck Makelaars / 24848 / 44
- De Graaf & Groot Makelaars / 24131 / 42
- Openkoop Makelaardij / 15406 / 42
- Heeren Makelaars / 24648 / 41

### Top 10 agents with gardens
Name / Id / Number Of Properties
- Broersma Makelaardij / 24067 / 25
- Hallie & Van Klooster Makelaardij / 24605 / 20
- Carla van den Brink B.V. / 24065 / 17
- Makelaardij Van der Linden Amsterdam / 24079 / 14
- Hoekstra en van Eck Amsterdam West / 24783 / 13
- Hoekstra en van Eck Amsterdam Noord / 24594 / 13
- De Graaf & Groot Makelaars / 24131 / 12
- Ramón Mossel Makelaardij o.g. B.V. / 24592 / 11
- Linger OG / 60557 / 9
- JA! Jaap Admiraal makelaardij / 24584 / 9
