export function formatDate(date: Date, format: string): string {
  switch (format) {
    case "dd/MM/yyyy":
      return (
        paddingNumer(date.getDate()) +
        "/" +
        paddingNumer(date.getMonth() + 1) +
        "/" +
        date.getFullYear()
      );

    default:
      return (
        paddingNumer(date.getDate()) +
        "-" +
        paddingNumer(date.getMonth() + 1) +
        "-" +
        date.getFullYear()
      );
  }
}

export function paddingNumer(num: number): string {
  if (num < 10) {
    return "0" + num;
  }

  return num + "";
}
