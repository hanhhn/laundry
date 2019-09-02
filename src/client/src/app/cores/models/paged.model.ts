export class PagedList<T> {
  pageIndex: number;
  pageSize: number;
  totalRecord: number;
  totalPage: number;
  dataSource: T[];

  constructor(json: any) {
    this.pageIndex = json.pageIndex;
    this.pageSize = json.pageSize;
    this.totalRecord = json.totalRecord;
    this.totalPage = json.totalPage;
    this.dataSource = json.dataSource;
  }
}
