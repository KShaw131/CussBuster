FROM microsoft/mssql-server-linux:2017-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Levvel1!
EXPOSE 1433/tcp

WORKDIR /app
COPY /Docker/CussBuster_DB/entrypoint.sh ./
COPY /Docker/CussBuster_DB/init.sql ./
COPY /Docker/CussBuster_DB/setup.sh ./

#ensures that scripts have correct rights to execute
RUN chmod +x ./setup.sh
RUN chmod +x ./entrypoint.sh

CMD /bin/bash ./entrypoint.sh
