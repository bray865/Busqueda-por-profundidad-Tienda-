```markdown name=README.md
# 🛍️ Búsqueda por Profundidad - Tienda

## 📋 Resumen del Proyecto

Este proyecto implementa un sistema de búsqueda y gestión de productos para una tienda utilizando el algoritmo de **búsqueda por profundidad (DFS - Depth-First Search)**. La aplicación permite realizar búsquedas eficientes de productos en una estructura de datos jerárquica, aplicando conceptos fundamentales de estructuras de datos y algoritmos.

### Características Principales:
- 🔍 Búsqueda por profundidad en productos
- 🏪 Gestión de inventario de tienda
- 📊 Exploración de categorías y subcategorías
- ⚡ Algoritmo DFS optimizado para búsquedas

---

## 🛠️ Tecnologías Utilizadas

| Tecnología | Versión | Descripción |
|-----------|---------|------------|
| **C#** | .NET Framework | Lenguaje principal de desarrollo |
| **.NET Framework** | 4.x+ | Framework de ejecución |
| **Visual Studio** | 2022+ | IDE recomendado para desarrollo |
| **Algoritmos** | DFS | Búsqueda por profundidad |

---

## 📥 Instalación

### Requisitos Previos
- Windows 7 o superior
- .NET Framework 4.5 o superior
- Visual Studio 2019+ (opcional pero recomendado)
- Git (para clonar el repositorio)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/bray865/Busqueda-por-profundidad-Tienda-.git
   cd Busqueda-por-profundidad-Tienda-
   ```

2. **Abrir la solución en Visual Studio**
   ```bash
   start Tienda.sln
   ```

3. **Restaurar dependencias**
   - En Visual Studio: Tools > NuGet Package Manager > Manage NuGet Packages for Solution

4. **Compilar la solución**
   - En Visual Studio: Ctrl + Shift + B

5. **Ejecutar la aplicación**
   - En Visual Studio: F5 o Ctrl + F5

---

## 📂 Estructura del Proyecto

```
Busqueda-por-profundidad-Tienda-/
├── Tienda/
│   ├── Program.cs
│   ├── Tienda.csproj
│   └── [Clases adicionales]
├── Tienda.sln
├── .gitignore
└── README.md
```

---

## 🚀 Uso

```csharp
Tienda tienda = new Tienda();
tienda.AgregarProducto("Electrónica", "Laptop Dell");
tienda.BuscarPorProfundidad("Laptop");
```

---

## 🔧 Compilación

### Visual Studio
1. Abre Tienda.sln
2. Ctrl + Shift + B
3. F5 para ejecutar

### .NET CLI
```bash
dotnet build -c Debug
dotnet run
```

---

## 📝 Algoritmo: DFS (Depth-First Search)

- ⏱️ Complejidad temporal: O(V + E)
- 💾 Complejidad espacial: O(V)
- 🎯 Uso: Exploración exhaustiva

---

## 👨‍💻 Autor

**bray865** - [GitHub](https://github.com/bray865)

---

⭐ **Si te fue útil, dale una estrella!**
```
