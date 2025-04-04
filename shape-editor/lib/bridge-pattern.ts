export interface Renderer {
  renderShape(shape: string): string;
}

export class VectorRenderer implements Renderer {
  renderShape(shape: string): string {
    return `Drawing ${shape} as vectors`;
  }
}

export class RasterRenderer implements Renderer {
  renderShape(shape: string): string {
    return `Drawing ${shape} as pixels`;
  }
}

export abstract class Shape {
  protected renderer: Renderer;

  constructor(renderer: Renderer) {
    this.renderer = renderer;
  }

  abstract draw(): string;
}

export class Circle extends Shape {
  draw(): string {
    return this.renderer.renderShape("Circle");
  }
}

export class Square extends Shape {
  draw(): string {
    return this.renderer.renderShape("Square");
  }
}

export class Triangle extends Shape {
  draw(): string {
    return this.renderer.renderShape("Triangle");
  }
}

export function createShape(type: string, renderMode: string): Shape {
  const renderer =
    renderMode === "vector" ? new VectorRenderer() : new RasterRenderer();

  switch (type) {
    case "circle":
      return new Circle(renderer);
    case "square":
      return new Square(renderer);
    case "triangle":
      return new Triangle(renderer);
    default:
      return new Circle(renderer);
  }
}
