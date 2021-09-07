## Homework1
 1. Настроить Git репозиторий и добавить преподавателя (с ролью чтение + запись)
2. В репозитории создать проект с названием Homework1 (последнующие проекты будут называтьсяя подобным образом)
3. В проекте реализовать:
   
   3.1. Сервис, реализующий интерфейс. В интерфейсе должен быть метод, который принимает какие-либо значения (минимум 2 аргумента) и возвращает значение.
    
    3.2. Юнит тесты (MS Test, nUnit, xUnit зависит от Вас), которые:
        
        3.2.1. Производят проверку метода (несколько вариаций входных параметров)
        
        3.2.2. Отдельный юнит тест с использованием библиотеки Moq ("замокать" сервис и использовать callback для сохранения переданных значений). Сделать проверку, совпадают ли значения из callback с передаваемыми значениями
        
        3.2.3. Отдельный юнит тест с примером использования библиотеки Bogus
## Homework2
1. Создать .Net Core MVC Web Application (Model-View-Controller)
2. В действии (action) Index добавить во ViewBag поле Message с текстовым значением "Hello world!"
3. Добавить юнит тесты для проверки контроллера (действие Index):
   
   3.1. Проверить, чтобы тип результата выполнения был ожидаемым.
    
    3.2. Проверить, чтобы ViewBag представления имел поле Message с ожидаемым значением.

## Homework3
1. Создать Web Api приложение
2. Для эндпоинта GET в WeatherForecastController детально описать контроллер через аттрибуты и нотации. Информация должна отображаться на странице swagger
    2.1. Указать возвращаемый тип контента
    2.2. Указать возможные коды ответов
    2.3. Указать что эндпоинт делает.
3. Добавить юнит тесты для эндпоинта

## Homework4
1. Создать пустое решение (empty solution) с именем Hometask4
2. Добавить новый WebApi-проект с именем Hometask4.WebApi
3. Добавить новый проект (class library) с именем Hometask4.DAL, где DAL - Data Access Layer
    3.1. Добавить папки:
        - EF - для EF DbContext
        - Entities - модели классов для хранения в бд
        - Interfaces - все используемые интерфейсы
        - Repositories - реализации репозиториев
4. Добавить новый проект (class library) с именем Hometask4.BLL, где BLL - Business Logic Layer
    4.1. Добавить папки:
        - Models - для бизнес моделей
        - DTO - для DTO классов (Data Transfer Object - классы, которые используются для получения / передачи данных в эндпоинтах Web WebApi)
        - Infrastructure - для вспомогательных классов
        - Interfaces - все используемые интерфейсы
        - Services - реализации интерфейсов
    4.2. Сюда перенести логику WeatherForecast
5. Добавить новый проект (unit tests) с именем Hometask4.Tests
    5.1. Добавить папки:
        - DAL - содержит тесты проекта Hometask4.DAL
        - BLL - содержит тесты проекта Hometask4.BLL
        - WebApi - содержит тесты проекта Hometask4.WebApi
