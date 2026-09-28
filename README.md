<h1 align="center">🏥 appReversoTask</h1>

---

<div align="center">

[![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code\&size=26\&pause=1000\&color=38BDF8\&center=true\&vCenter=true\&width=900\&lines=🏥+Sistema+de+Gerenciamento+de+Clínica;👨‍⚕️+Cadastro+de+Médicos+e+Pacientes;📅+Gerenciamento+de+Consultas;🔐+Sistema+de+Autenticação)](https://git.io/typing-svg)

</div>

---

<p align="center">
Sistema desenvolvido com <b>ASP.NET Core MVC, C# e SQL Server</b> ✨
</p>

---

## 🚀 Tecnologias Utilizadas

<div align="center">

![.NET](https://img.shields.io/badge/.NET-1D4ED8?style=for-the-badge\&logo=dotnet\&logoColor=white)
![C#](https://img.shields.io/badge/C%23-2563EB?style=for-the-badge\&logo=csharp\&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-0284C7?style=for-the-badge\&logo=dotnet\&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-3B82F6?style=for-the-badge\&logo=dotnet\&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-0EA5E9?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-0369A1?style=for-the-badge\&logo=bootstrap\&logoColor=white)

</div>

---

## 📌 Sobre o Projeto

O **appReversoTask** é um sistema web desenvolvido para fins acadêmicos utilizando a arquitetura **ASP.NET Core MVC**.

A aplicação permite gerenciar **pacientes, médicos e consultas**, além de possuir um sistema de autenticação por **CPF** utilizando cookies.

O projeto utiliza **Entity Framework Core** para comunicação com o banco de dados **SQL Server**.

---

## 🚀 Funcionalidades

* 👤 Cadastro de pacientes
* 👨‍⚕️ Cadastro de médicos
* 📅 Cadastro de consultas
* ✏️ Edição de registros
* 🗑️ Exclusão de registros
* 🔎 Visualização de informações
* 🔐 Login utilizando CPF
* 🚪 Logout
* 👤 Identificação do paciente autenticado
* 📋 Visualização das consultas do paciente

---

## 🗄️ Banco de Dados

O projeto utiliza **SQL Server** através do **Entity Framework Core**.

Banco utilizado:

```text
dbClinicaBM
```

Principais entidades:

```text
Paciente
Médico
Consulta
```

Relacionamentos:

```text
Paciente ────< Consulta >──── Médico
```

A conexão é configurada através do arquivo:

```text
appsettings.json
```

---

## 📦 Pacotes Utilizados

```text
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.VisualStudio.Web.CodeGeneration.Design
```

---

## 🔐 Autenticação

O sistema utiliza autenticação baseada em **Cookies**.

O usuário realiza login utilizando o **CPF cadastrado do paciente**.

Após a autenticação, o sistema identifica o paciente através de **Claims** e permite o acesso às suas consultas.

---

## 📁 Estrutura do Projeto

```text
appReversoTask/
│
├── Controllers/
│   ├── AccountController.cs
│   ├── ConsultaController.cs
│   ├── HomeController.cs
│   ├── MedicoController.cs
│   └── PacienteController.cs
│
├── Models/
│   ├── Consulta.cs
│   ├── DbClinicaBmContext.cs
│   ├── Medico.cs
│   ├── Paciente.cs
│   └── LoginViewModel.cs
│
├── Views/
│   ├── Account/
│   ├── Consulta/
│   ├── Medico/
│   ├── Paciente/
│   ├── Home/
│   └── Shared/
│
├── wwwroot/
├── appsettings.json
├── Program.cs
└── appReversoTask.csproj
```

---

## ⚙️ Como Executar

### 1️⃣ Abra o projeto

Abra a solução:

```text
appReversoTask.sln
```

utilizando o **Visual Studio 2022**.

### 2️⃣ Configure o banco

Edite a Connection String no:

```text
appsettings.json
```

### 3️⃣ Restaure os pacotes

```bash
dotnet restore
```

### 4️⃣ Execute o projeto

Pressione:

```text
F5
```

ou utilize:

```bash
dotnet run
```

---

## 🎯 Objetivos de Aprendizagem

O projeto permite praticar:

* 💻 C#
* 🌐 ASP.NET Core MVC
* 🏗️ Arquitetura MVC
* 🔄 CRUD
* 🗄️ Entity Framework Core
* 🗃️ SQL Server
* 🔐 Autenticação por Cookies
* 👤 Claims
* 📋 Razor Views
* 🎨 Bootstrap
* ⚡ Operações assíncronas

---

<div align="center">

💙 Desenvolvido para fins acadêmicos

</div>
