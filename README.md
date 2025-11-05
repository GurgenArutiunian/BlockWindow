# Grid Visualizer

## Как запустить
1. Открыть сцену в `Assets/Scenes/SampleScene`.  
2. Настройки отображения вынесены в ScriptableObject `Assets/Grid Settings`.  
3. Файл `grid.txt` должен лежать в `Assets/StreamingAssets/`. 
4. Запустить сцену.  
Управление: **WASD** — движение окна, **R** — перезагрузка файла.

## Реализованные классы
- **GridVisualizerManager** — босс. говорит кому когда инициализироваться, по событиям из **GridInputActions** двигает "окно"  
- **GridFileLoader** — читает и парсит `grid.txt`. Возвращает в формате **GridData**.
- **GridData** – хранит массив данных и информацию о требуемой ширине и высоте.
- **GridVisualizer** — обновляет цвета и позиции кубов.
- **GridInputActions** – обрабатывает нажатия на клавиши
- **GridCubeFactory** — создаёт кубы.  
- **MaterialFactory** — создаёт материалы по цветам.  

Файл: `Assets/StreamingAssets/grid.txt`  
Цвета для кубов, их размеры и размеры сетки настраиваются в ScriptableObject `Assets/Grid Settings`.  
