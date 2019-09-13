export class Post {
  id: string;
  uniqueUrl: string;
  image: string;
  title: string;
  description: string;
  body: string;
  isPublished: boolean;
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
  id: string;
  uniqueUrl: string;
  image: string;
  title: string;
  description: string;
  body: string;
  isPublished: string;
  publishedDate: Date;
  tags: string[];
}
