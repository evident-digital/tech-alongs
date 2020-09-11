# How to run

1. Create a MSSQL database called 'evimatch'
2. Add connectionstring to user secrets in the 'EviMatch' project

```json
{
  "ConnectionStrings": {
    "EviMatchDatabase": "Data Source=<DATABASE SERVER NAME>;Initial Catalog=evimatch;Integrated Security=True"
  }
}
```

3. Run app from VS2019