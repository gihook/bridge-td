const rows = Array.from(
  document.querySelectorAll(
    "body > table > tbody > tr > td > table > tbody > tr",
  ),
).filter((x) => x.innerHTML.includes("&"));

function getEntry(td) {
  const th = td.querySelector("th")?.innerHTML;

  if (th != null) {
    const s1 = th.split(" ");
    const s2 = s1[1].split("&");
    const boardNumber = s2[0];
    return {
      boardNumber,
      th,
      s1,
      s2,
    };
  }

  const cols = Array.from(td.querySelectorAll("td"));

  return {
    nsId: Number(cols[0]?.innerHTML),
    ewId: Number(cols[1]?.innerHTML),
    contract: cols[2]?.innerHTML,
    declarer: cols[3]?.innerHTML,
    lead: cols[4]?.innerHTML,
    score: cols[5]?.innerHTML,
    nsResult: cols[7]?.innerHTML,
    ewResult: cols[8]?.innerHTML,
    nsPair: cols[9]?.innerHTML,
    ewPair: cols[10]?.innerHTML,
  };
}

const boardInfos = rows.map((x) => getEntry(x));

let currentBoardNumber = 0;

const boardResults = boardInfos.reduce((a, c) => {
  const { boardNumber } = c;
  if (boardNumber) {
    currentBoardNumber = boardNumber;
    return { ...a, [boardNumber]: [] };
  }

  return { ...a, [currentBoardNumber]: [...a[currentBoardNumber], c] };
}, {});

const resultRows = Array.from(
  document.querySelectorAll("body > table:nth-child(8) > tbody > tr"),
).filter((r) => !r.innerHTML?.includes("OVERALL"));

function getResultItem(tr) {
  const cols = Array.from(tr.querySelectorAll("td"));
  return {
    rank: Number(cols[0].innerHTML.replace("=", "")),
    pairId: Number(cols[1].innerHTML),
    pairNames: cols[2].innerHTML,
    numberOfBoards: cols[3].innerHTML,
    score: Number(cols[4].innerHTML),
    maxScore: Number(cols[5].innerHTML),
    tournamentScore: Number(cols[6].innerHTML),
  };
}

const tournamentResults = resultRows.map(getResultItem);

const result = { boardResults, tournamentResults };
console.log({ result });
