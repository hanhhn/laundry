export class Post {
  id: number;
  uniqueUrl: string;
  image: string;
  title: string;
  description: number;
  body: number;
  isPublished: number;
  publishedDate: Date;
  tags: string[];

  constructor(json) {
    this.id = json.id;
    this.uniqueUrl = json.uniqueUrl;
    this.image = json.image;
    this.title = json.title;
    this.description = json.description;
    this.body = json.body;
    this.isPublished = json.isPublished;
    this.publishedDate = json.publishedDate;
    this.tags = json.tags ? json.tags : [];
  }
}

export class PostRequest {
  id: number;
  uniqueUrl: string;
  image: string;
  title: string;
  description: number;
  body: number;
  isPublished: number;
  publishedDate: Date;
  tags: string[];
}
