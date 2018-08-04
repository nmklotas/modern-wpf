# Modern WPF architecture sample

[![EO principles respected here](http://www.elegantobjects.org/badge.svg)](http://www.elegantobjects.org)

1. App is divided and modularized into folders by feature, not by "technological" anemic names like "Models", "ViewModels", "Services" on the root.
2. Controls & resources modularized, not contained in one global place.
3. Objects are not dumb bags of data.
4. Logging is done using AOP techniques like DynamicProxy and Weaving.
5. API details are abstracted from ViewModels.
6. ViewModels communicating using mediator pattern.
7. Caliburn.Micro MVVM framework is used.
