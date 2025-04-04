"use client";

import { useEffect, useRef, useState } from "react";

interface Shape {
  type: string;
  renderMode: string;
  x: number;
  y: number;
}

interface CanvasProps {
  shapes: Shape[];
  onResize?: (width: number, height: number) => void;
}

export function Canvas({ shapes, onResize }: CanvasProps) {
  const canvasRef = useRef<HTMLCanvasElement>(null);
  const [dimensions, setDimensions] = useState({ width: 0, height: 0 });

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;

    const updateCanvasSize = () => {
      const rect = canvas.getBoundingClientRect();
      const newWidth = rect.width;
      const newHeight = rect.height;

      if (dimensions.width !== newWidth || dimensions.height !== newHeight) {
        canvas.width = newWidth;
        canvas.height = newHeight;
        setDimensions({ width: newWidth, height: newHeight });

        if (onResize) {
          onResize(newWidth, newHeight);
        }
      }
    };

    updateCanvasSize();

    const resizeObserver = new ResizeObserver(updateCanvasSize);
    resizeObserver.observe(canvas);

    return () => {
      resizeObserver.disconnect();
    };
  }, [onResize, dimensions]);

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;

    const ctx = canvas.getContext("2d");
    if (!ctx) return;

    drawGrid(ctx, canvas.width, canvas.height);

    shapes.forEach((shape) => {
      ctx.save();

      if (shape.renderMode === "vector") {
        const gradient = ctx.createRadialGradient(
          shape.x,
          shape.y,
          0,
          shape.x,
          shape.y,
          50
        );
        gradient.addColorStop(0, "rgba(59, 130, 246, 0.8)");
        gradient.addColorStop(1, "rgba(37, 99, 235, 0.6)");

        ctx.fillStyle = gradient;
        ctx.strokeStyle = "#1d4ed8";
        ctx.lineWidth = 3;
        ctx.setLineDash([]);

        ctx.shadowColor = "rgba(0, 0, 0, 0.2)";
        ctx.shadowBlur = 10;
        ctx.shadowOffsetX = 2;
        ctx.shadowOffsetY = 2;
      } else {
        ctx.strokeStyle = "#be185d";
        ctx.lineWidth = 2;
        ctx.setLineDash([4, 2]);

        const pixelSize = 5;
        const patternCanvas = document.createElement("canvas");
        patternCanvas.width = pixelSize * 2;
        patternCanvas.height = pixelSize * 2;
        const patternCtx = patternCanvas.getContext("2d");

        if (patternCtx) {
          patternCtx.fillStyle = "rgba(219, 39, 119, 0.2)";
          patternCtx.fillRect(0, 0, pixelSize, pixelSize);
          patternCtx.fillRect(pixelSize, pixelSize, pixelSize, pixelSize);

          patternCtx.fillStyle = "rgba(236, 72, 153, 0.3)";
          patternCtx.fillRect(pixelSize, 0, pixelSize, pixelSize);
          patternCtx.fillRect(0, pixelSize, pixelSize, pixelSize);

          const pattern = ctx.createPattern(patternCanvas, "repeat");
          if (pattern) {
            ctx.fillStyle = pattern;
          } else {
            ctx.fillStyle = "rgba(219, 39, 119, 0.4)";
          }
        }
      }

      switch (shape.type) {
        case "circle":
          ctx.beginPath();
          ctx.arc(shape.x, shape.y, 40, 0, Math.PI * 2);
          ctx.fill();
          ctx.stroke();
          break;

        case "square":
          ctx.beginPath();
          ctx.rect(shape.x - 35, shape.y - 35, 70, 70);
          ctx.fill();
          ctx.stroke();
          break;

        case "triangle":
          ctx.beginPath();
          ctx.moveTo(shape.x, shape.y - 40);
          ctx.lineTo(shape.x + 40, shape.y + 30);
          ctx.lineTo(shape.x - 40, shape.y + 30);
          ctx.closePath();
          ctx.fill();
          ctx.stroke();
          break;
      }

      ctx.shadowColor = "transparent";
      ctx.shadowBlur = 0;
      ctx.shadowOffsetX = 0;
      ctx.shadowOffsetY = 0;

      const text = `${
        shape.type === "circle"
          ? "Коло"
          : shape.type === "square"
          ? "Квадрат"
          : "Трикутник"
      } (${shape.renderMode === "vector" ? "вектор" : "растр"})`;

      ctx.font = "bold 12px sans-serif";
      const textWidth = ctx.measureText(text).width;

      ctx.fillStyle = "rgba(255, 255, 255, 0.85)";
      ctx.strokeStyle = shape.renderMode === "vector" ? "#3b82f6" : "#db2777";
      ctx.lineWidth = 1;

      const labelX = shape.x - textWidth / 2 - 10;
      const labelY = shape.y + 50;
      const labelWidth = textWidth + 20;
      const labelHeight = 24;

      ctx.beginPath();
      ctx.roundRect(labelX, labelY, labelWidth, labelHeight, 8);
      ctx.fill();
      ctx.stroke();

      ctx.fillStyle = shape.renderMode === "vector" ? "#1e40af" : "#9d174d";
      ctx.textAlign = "center";
      ctx.textBaseline = "middle";
      ctx.fillText(text, shape.x, labelY + labelHeight / 2);

      ctx.restore();
    });
  }, [shapes, dimensions]);

  const drawGrid = (
    ctx: CanvasRenderingContext2D,
    width: number,
    height: number
  ) => {
    ctx.clearRect(0, 0, width, height);

    ctx.strokeStyle = "rgba(226, 232, 240, 0.8)";
    ctx.lineWidth = 1;

    const gridSize = 20;

    for (let x = 0; x <= width; x += gridSize) {
      ctx.beginPath();
      ctx.moveTo(x, 0);
      ctx.lineTo(x, height);
      ctx.stroke();
    }

    for (let y = 0; y <= height; y += gridSize) {
      ctx.beginPath();
      ctx.moveTo(0, y);
      ctx.lineTo(width, y);
      ctx.stroke();
    }
  };

  return <canvas ref={canvasRef} className="w-full h-full rounded-lg" />;
}
