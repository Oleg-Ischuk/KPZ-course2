"use client";

import { useState, useCallback } from "react";
import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { RadioGroup, RadioGroupItem } from "@/components/ui/radio-group";
import { Label } from "@/components/ui/label";
import { Canvas } from "@/components/canvas";
import { createShape } from "@/lib/bridge-pattern";

export default function ShapeEditor() {
  const [selectedShape, setSelectedShape] = useState("circle");
  const [renderMode, setRenderMode] = useState("vector");
  const [shapes, setShapes] = useState<
    Array<{ type: string; renderMode: string; x: number; y: number }>
  >([]);
  const [consoleOutput, setConsoleOutput] = useState<string[]>([]);
  const [canvasSize, setCanvasSize] = useState({ width: 800, height: 600 });

  const updateCanvasSize = useCallback((width: number, height: number) => {
    setCanvasSize((prevSize) => {
      // Only update if the size actually changed
      if (prevSize.width !== width || prevSize.height !== height) {
        return { width, height };
      }
      return prevSize;
    });
  }, []);

  const addShape = () => {
    const shape = createShape(selectedShape, renderMode);
    const output = shape.draw();

    let newShape;
    let attempts = 0;
    let validPosition = false;

    const padding = 50;

    while (!validPosition && attempts < 50) {
      attempts++;

      const x =
        Math.floor(Math.random() * (canvasSize.width - padding * 2)) + padding;
      const y =
        Math.floor(Math.random() * (canvasSize.height - padding * 2)) + padding;

      newShape = {
        type: selectedShape,
        renderMode: renderMode,
        x,
        y,
      };

      validPosition = !shapes.some((existingShape) => {
        const distance = Math.sqrt(
          Math.pow(existingShape.x - x, 2) + Math.pow(existingShape.y - y, 2)
        );

        const minDistance = 100;
        return distance < minDistance;
      });
    }

    if (newShape && validPosition) {
      setShapes([...shapes, newShape]);
      setConsoleOutput([...consoleOutput, output]);
    } else if (newShape) {
      setShapes([...shapes, newShape]);
      setConsoleOutput([
        ...consoleOutput,
        output + " (Увага: перекриття фігур через брак місця)",
      ]);
    }
  };

  const clearShapes = () => {
    setShapes([]);
    setConsoleOutput([]);
  };

  return (
    <div className="min-h-screen bg-gradient-to-b from-gray-50 to-gray-100 p-6">
      <div className="max-w-7xl mx-auto">
        <header className="mb-10 text-center">
          <h1 className="text-3xl font-bold text-gray-800 mb-2">
            Графічний редактор
          </h1>
          <p className="text-gray-600">
            Демонстрація шаблону проектування Міст
          </p>
        </header>

        <div className="flex flex-col-reverse md:flex-row gap-8">
          <div className="md:w-1/3 lg:w-1/4">
            <Card className="overflow-hidden border-0 shadow-lg rounded-2xl">
              <div className="bg-gradient-to-r from-blue-500 to-purple-500 p-4 rounded-t-2xl">
                <h2 className="text-xl font-bold text-white">
                  Елементи керування
                </h2>
              </div>

              <div className="p-6 space-y-6">
                <div className="space-y-3">
                  <Label
                    htmlFor="shape"
                    className="text-sm font-medium text-gray-700"
                  >
                    Тип фігури
                  </Label>
                  <Select
                    value={selectedShape}
                    onValueChange={setSelectedShape}
                  >
                    <SelectTrigger
                      id="shape"
                      className="w-full border-gray-300 rounded-xl shadow-sm"
                    >
                      <SelectValue placeholder="Виберіть фігуру" />
                    </SelectTrigger>
                    <SelectContent className="rounded-xl">
                      <SelectItem value="circle">Коло</SelectItem>
                      <SelectItem value="square">Квадрат</SelectItem>
                      <SelectItem value="triangle">Трикутник</SelectItem>
                    </SelectContent>
                  </Select>
                </div>

                <div className="space-y-3">
                  <Label className="text-sm font-medium text-gray-700">
                    Режим рендерингу
                  </Label>
                  <RadioGroup
                    value={renderMode}
                    onValueChange={setRenderMode}
                    className="space-y-2"
                  >
                    <div className="flex items-center space-x-2 p-2 rounded-xl hover:bg-gray-50">
                      <RadioGroupItem value="vector" id="vector" />
                      <Label htmlFor="vector" className="cursor-pointer">
                        Векторна графіка
                      </Label>
                    </div>
                    <div className="flex items-center space-x-2 p-2 rounded-xl hover:bg-gray-50">
                      <RadioGroupItem value="raster" id="raster" />
                      <Label htmlFor="raster" className="cursor-pointer">
                        Растрова графіка
                      </Label>
                    </div>
                  </RadioGroup>
                </div>

                <div className="space-y-3 pt-2">
                  <Button
                    onClick={addShape}
                    className="w-full bg-gradient-to-r from-blue-500 to-purple-500 hover:from-blue-600 hover:to-purple-600 text-white border-0 py-2 rounded-xl"
                  >
                    Додати фігуру
                  </Button>
                  <Button
                    onClick={clearShapes}
                    variant="outline"
                    className="w-full border border-gray-300 text-gray-700 hover:bg-gray-50 py-2 rounded-xl"
                  >
                    Очистити все
                  </Button>
                </div>
              </div>

              <div className="border-t border-gray-200 p-6">
                <h3 className="text-sm font-medium text-gray-700 mb-3">
                  Консольний вивід:
                </h3>
                <div className="bg-gray-800 text-gray-100 p-4 rounded-xl text-sm h-48 overflow-y-auto font-mono">
                  {consoleOutput.length === 0 ? (
                    <div className="text-gray-400 italic">
                      Консольний вивід появиться тут...
                    </div>
                  ) : (
                    consoleOutput.map((output, index) => (
                      <div key={index} className="py-1">
                        <span className="text-green-400">&gt; </span>
                        {output}
                      </div>
                    ))
                  )}
                </div>
              </div>
            </Card>
          </div>

          <div className="md:w-2/3 lg:w-3/4 mb-8 md:mb-0">
            <Card className="overflow-hidden border-0 shadow-lg h-full rounded-2xl">
              <div className="bg-gradient-to-r from-blue-500 to-purple-500 p-4 rounded-t-2xl">
                <h2 className="text-xl font-bold text-white">Полотно</h2>
              </div>

              <div className="p-6 h-[calc(100%-64px)]">
                <div className="bg-white rounded-xl shadow-inner border border-gray-200 h-full overflow-hidden">
                  <Canvas shapes={shapes} onResize={updateCanvasSize} />
                </div>
              </div>
            </Card>
          </div>
        </div>
      </div>
    </div>
  );
}
