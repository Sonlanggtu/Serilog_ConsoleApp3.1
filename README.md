# Serilog_ConsoleApp3.1
This project demo log file and log console with console app .NetCore 3.1

Note:
File log default path: {Project}\bin\Debug

Show log UI with Serilog Seq
B1: Download software Seq serilog https://datalust.co/download 
	or docker Seq Home: https://hub.docker.com/r/datalust/seq
	link docker: docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest

B2: Add .WriteTo.Seq("http://localhost:5341") and Log.CloseAndFlush() in code
B3: Addresst default http://localhost:5341/  show log.