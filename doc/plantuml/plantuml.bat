echo off
cd %~dp0
for %%f in (%*) do (
  java -jar plantuml.jar %%f
)
