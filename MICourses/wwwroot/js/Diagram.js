function createChart(canvasId, config) {
    const ctx = document.getElementById(canvasId).getContext('2d');
    new Chart(ctx, config);
}