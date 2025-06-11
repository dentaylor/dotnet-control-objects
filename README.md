# Control Object Pattern (COP)

**The Control Object Pattern (COP)** is a scalable, reusable abstraction for modeling UI components in test automation. Unlike traditional Page Object Models (POMs), which tie logic to specific pages, COP represents each UI control (e.g., dropdowns, checkboxes, sliders) as a standalone object with clear responsibilities and consistent APIs.

Developed by an SDET with 25+ years of experience, this pattern will eventually be framework-agnostic and compatible with **Playwright**, **Selenium**, and **Puppeteer**, allowing teams to build robust UI tests using modern component architectures like **PrimeNG**, **React**, and **Angular**.

---

## Why Use the Control Object Pattern?

### COP Advantages:
- **Encapsulation** of reusable UI behavior in control objects
- **Driver-agnostic** architecture (`ILocateElements` abstraction (pending))
- **Composable and testable** outside of page context
- **Scales naturally** with modern UI frameworks (PrimeNG, React MUI, etc.)
- **Async-first design** compatible with modern automation tools (Playwright)

---

## Features

- Reusable Control Objects: `Dropdown`, `Checkbox`, `ComboBox`, `MultiDropdown`, `Progress`, `Radio`, etc.
- Adapter-based locator model (`ILocateElements`) supporting:
  - Playwright (.NET)
  - Selenium WebDriver
  - Puppeteer Sharp (in progress)
- Storybook-style demo app in **Angular 17 + PrimeNG**
- Real-world test examples using **MSTest**
- Clean Arrange–Act–Assert structure in all tests

---

| Control Type | Interface        | Class Name      |
| ------------ | ---------------- | --------------- |
| Dropdown     | `IDropdown`      | `Dropdown`      |
| Checkbox     | `ICheckbox`      | `Checkbox`      |
| ComboBox     | `IComboBox`      | `ComboBox`      |
| MultiSelect  | `IMultiDropdown` | `MultiDropdown` |
| RadioButton  | `IRadio`         | `Radio`         |
| TextArea     | `ITextbox`       | `TextArea`      |
| Progress     | `IProgress`      | `Progress`      |
| Meter        | `IMeter`         | `Meter`         |

More controls and UI libraries are actively being added.

## Architectural Summary
- Each Control Object models one UI behavior, not a page.
- Interactions (e.g., Set, Select, Click) are defined via small, focused interfaces.
- Tests interact only with control contracts — not DOM selectors.
- Swappable ILocateElements adapter allows for driver-level decoupling.
- Designed for long-term maintenance in large UI test suites.

## Contributing
- We welcome contributions of:
- New control objects (e.g., PrimeNG Calendar, MUI Slider)
- Locator adapters for new frameworks (e.g., Cypress, TestCafe)
- Enhancements to test scaffolding and examples
- Start a discussion or open a pull request — let’s build a universal UI automation layer together.

## License
- This project is licensed under the MIT License.
