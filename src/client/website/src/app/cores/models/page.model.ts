export class Page {
  id: string;
  uniqueUrl: string;
  image: string;
  title: string;
  description: string;
  body: string;
  sortOrder: number;
  tags: string[];

  constructor(json) {
    this.id = json.id;
    this.uniqueUrl = json.uniqueUrl;
    this.image = json.image;
    this.title = json.title;
    this.description = json.description;
    this.body = json.body;
    this.sortOrder = json.sortOrder;
    this.tags = json.tags ? json.tags : [];
  }
}

export class PageRequest {
  id: string;
  uniqueUrl: string;
  image: string;
  title: string;
  description: string;
  body: string;
  sortOrder: number;
}
