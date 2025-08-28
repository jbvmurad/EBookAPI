# EBookAPI with JWT Authentication

Bu layihə ASP.NET Core Web API istifadə edilərək hazırlanmışdır və Clean Code Architecture prinsipini özündə birləşdirir. Layihədə Kitab satışı üçün əsas CRUD əməliyyatları (E-Kitab və istifadəçilərlə bağlı) yer alır və yalnız doğrulanmış istifadəçilər bu əməliyyatları icra edə bilər.


## ✨ İstifadə qaydaları
- Command Prompt proqramından cd "proyekti yerləşdirəcəyiniz ad/EBook/EBook" olaraq qeyd edin
- docker-compose up --build komutundan istifadə edib Container yaradın
- Container yarandığı an ( http://localhost:8080/swagger ) linkindən istifadə edin. Diqqət! swagger endpoint önəmlidir
- Postman proqramı vasitəsi ilə http://localhost:5000/api/Auth/login url -ə appsetting.json da olan Admin Credential məlumatlarını daxil edin
- Alınan tokeni Authorization bölməsinə yerləşdirib kimlik doğrulaması edin
- Budur artıq admin hesabınız təstiqləndi rahatlıqla test edin
- Database məlumatları əldə etmək istəyən ( http://localhost:8082 ) lokalhost -a daxil olsun və (admin/admin123)-bu məlumatları daxil etsin


## ✨ Texnologiyalar

- ![ASP.NET Core](https://img.shields.io/badge/-ASP.NET%20Core-512BD4?style=flat-square&logo=.net&logoColor=white) ASP.NET Core Web API  
- ![MongoDB Driver](https://img.shields.io/badge/-MongoDB%20Driver-47A248?style=flat-square&logo=mongodb&logoColor=white) MongoDB .NET Driver (MongoDriverCore)  
- ![MongoDB](https://img.shields.io/badge/-MongoDB-13AA52?style=flat-square&logo=mongodb&logoColor=white) MongoDB  
- ![AutoMapper](https://img.shields.io/badge/-AutoMapper-E44D27?style=flat-square&logo=automapper&logoColor=white) AutoMapper  
- ![JWT](https://img.shields.io/badge/-JWT-000000?style=flat-square&logo=json-web-tokens&logoColor=white) JWT Bearer Authentication  
- ![Postman](https://img.shields.io/badge/-Postman-FF6C37?style=flat-square&logo=postman&logoColor=white) Postman  
- ![Docker](https://img.shields.io/badge/-Docker-2496ED?style=flat-square&logo=docker&logoColor=white) Docker  
