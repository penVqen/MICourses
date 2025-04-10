export function createChart(canvasId, config) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    const ctx = canvas.getContext('2d');
    const chart = new Chart(ctx, config);

    return {
        update: () => chart.update(),
        destroy: () => chart.destroy()
    };
}