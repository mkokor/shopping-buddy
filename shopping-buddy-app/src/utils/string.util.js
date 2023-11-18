const capitalizeWord = (word) => {
  if (!word || word.length === 0) return "";
  return word[0].toUpperCase() + word.toLowerCase().slice(1);
};

export const capitalizeText = (text) => {
  return text
    .split(" ")
    .map((word) => capitalizeWord(word))
    .join(" ");
};
