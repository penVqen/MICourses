const chartInstances = {};

export async function createChart(canvasId, config) {
    const ensureCanvas = () => {
        return new Promise((resolve) => {
            const check = () => {
                const canvas = document.getElementById(canvasId);
                if (canvas) resolve(canvas);
                else setTimeout(check, 50);
            };
            check();
        });
    };

    const canvas = await ensureCanvas();

    // Удаляем предыдущую диаграмму, если она уже существует
    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
        delete chartInstances[canvasId];
    }

    const ctx = canvas.getContext('2d');
    const chart = new Chart(ctx, config);

    chartInstances[canvasId] = chart;

    return {
        update: () => chart.update(),
        destroy: () => {
            chart.destroy();
            delete chartInstances[canvasId];
        }
    };
}
