# Finanzas Personales API 💰

API RESTful desarrollada con .NET Core para la gestión de deudas y finanzas personales.
Este proyecto documenta mi transición profesional de la gestión comercial al desarrollo de software, aplicando buenas prácticas de arquitectura y tipado fuerte.

## 🚀 Tecnologías
* **Lenguaje:** C# (.NET 8/9)
* **Tipo de Proyecto:** Web API
* **Datos:** SQL Server (Próximamente) / Entity Framework Core

## 📅 Bitácora de Cambios (Changelog)

### [v0.1.0] - Estructura Inicial - 2025-12-15
**Agregado**
* Configuración inicial del proyecto en Visual Studio 2022 con soporte HTTPS y OpenAPI (Swagger).
* **Modelo `Deuda`:** Definición de la entidad principal.
    * Se decidió usar `decimal` en lugar de `float` para `Monto` y `CostoFinancieroTotal` para garantizar precisión financiera.
    * Implementación de `FechaVencimiento` y propiedad calculada `EstaVencida` para lógica de negocio automática.
* Integración con GitHub para control de versiones.

---
*Autor: Jose Armando Lopez*