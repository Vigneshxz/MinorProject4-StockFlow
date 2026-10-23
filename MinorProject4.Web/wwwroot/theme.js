
window.stockFlowTheme = {
    setTheme: function (theme) {
        document.documentElement.setAttribute(
            "data-bs-theme", theme
        );

        localStorage.setItem("stockflow-theme", theme);
    },

    getTheme: function () {
        const theme =
            localStorage.getItem("stockflow-theme") || "light";

        document.documentElement.setAttribute(
            "data-bs-theme", theme
        );

        return theme === "dark" ? "Dark" : "Light";
    }
};

// Apply the saved theme on initial load.
window.stockFlowTheme.getTheme();

// Reapply the theme after Blazor navigates to another page.
if (window.Blazor) {
    window.Blazor.addEventListener("enhancedload", function () {
        window.stockFlowTheme.getTheme();
    });
}
