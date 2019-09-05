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

export function fromDate(value: string): Date {
  return new Date(value);
}

export function paddingNumer(num: number): string {
  if (num < 10) {
    return "0" + num;
  }

  return num + "";
}

export function getDate(date: Date): string {
  const day = date.getDate(); // yields date
  const month = date.getMonth() + 1; // yields month (add one as '.getMonth()' is zero indexed)
  const year = date.getFullYear(); // yields year
  const hour = date.getHours(); // yields hours
  const minute = date.getMinutes(); // yields minutes
  const second = date.getSeconds(); // yields seconds

  // After this construct a string with the above results as below
  return (
    month + "/" + day + "/" + year + " " + hour + ":" + minute + ":" + second
  );
}
