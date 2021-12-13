FROM mcr.microsoft.com/mssql/server:2019-latest
# Create work directory
RUN mkdir -p /usr/work
COPY . /usr/work
WORKDIR /usr/work

ENV MSSQL_SA_PASSWORD=YouPassword_123
ENV ACCEPT_EULA=true
EXPOSE 8080

RUN /opt/mssql/bin/sqlservr & sleep 30;