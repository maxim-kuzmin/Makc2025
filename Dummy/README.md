# Dummy (Пустышка)

## Назначение

Предоставляет шаблонный код для старта нового приложения на базе .NET/C# и React/Next.js.

## Frontend

За оразец взят https://nextjs.org/learn

## Backend. Микросервисы:

1. Gateway - Шлюз

Направляет запросы и команды от клиентов другим микросервисам

2. Writer - Писатель

Изменяет сущности (добавляет, обновляет, удаляет)

3. Reader - Читатель (пока не реализовано)

Читает сущности

4. Coordinator - Координатор  (пока не реализовано)

Координирует распределённые транзакции через отправку в очередь сообщений о фиксации или откате транзакций

## Взаимодействие микросервисов

1. Для изменения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет команду в микросервис Writer

2. Для чтения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет запрос в микросервис Reader

3. После изменения данных микросервис Writer отправляет событие изменения данных в очередь

4. Микросервис Coordinator извлекает из очереди сообщения о событиях, запускает транзакции и отправляет в очередь сообщения об их фиксации или откате

5. Микросервис Reader извлекает из очереди сообщение о событии изменения данных, обрабатывает его, создаёт событие об окончании обработки события изменения данных, отправляет в очередь сообщение об этом событии, извлекает из очереди сообщение о фиксации или откате события изменения данных, обрабатывает фиксацию или откат

## Сертификат

https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-9.0

1. Создать .pfx-файл самоподписанного сертификата для HTTPS:

```
dotnet dev-certs https -ep .\https\cert.pfx -p Makc!678
```

2. Установить openssl, если он ещё не установлен:

```
winget install openssl
```

3. Создать .crt-файл открытого ключа из .pfx-файла сертификата:

```
openssl pkcs12 -in .\https\cert.pfx -clcerts -nokeys -out .\https\cert.crt
```

4. Создать .rsa-файл закрытого ключа из .pfx-файла сертификата:

```
openssl pkcs12 -in .\https\cert.pfx -nocerts -nodes -out .\https\cert.rsa
```

5. Сделать самоподписанные сертификаты доверенными на локальной машине:

```
dotnet dev-certs https --trust
```

## Миграции

1. Добавить миграцию с именем InitialCreate:

```
cd .\src\Backend\src\Writer\src\Infrastructure\EntityFrameworkForPostgreSQL

dotnet ef migrations add InitialCreate --startup-project ../../Apps/WebApp --output-dir ./App/Db/Migrations
```

2. Применить все миграции:

```
cd .\src\Backend\src\Writer\src\Infrastructure\EntityFrameworkForPostgreSQL

dotnet ef database update --startup-project ../../Apps/WebApp
```
