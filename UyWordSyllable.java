package com.zerak.view;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.annotation.SuppressLint;

public class UyWordSyllable {

	/**
	 * 维吾尔文分音节的JAVA程序
	 * @param input 输入的维吾尔文单词
	 * @return 返回成功分音阶的List集合
	 */
	@SuppressLint("UseSparseArrays")
	public List<String> getSyllable(String input) {
		List<String> result = new ArrayList<String>();
		int nWordLength = input.length();
		if (input == null || nWordLength < 2) {
			result.add(input);
			return result;
		}
		HashMap<Integer, Integer> mapVowelPosition = new HashMap<Integer, Integer>();
		HashMap<Integer, Integer> mapConsCount = new HashMap<Integer, Integer>();//保存不是母音的字符位置和长度
		int nPositionIndex = 0;
		String tems = input;
		String remainword = input;//保存每次切分完毕后剩下的字符
		boolean bVowel = false;
		boolean blnFChCons = false; 
		int iConsCount = 0;
		for (int i = 0; i <= (nWordLength - 1); i++) {
			char chrOne = tems.charAt(0);
			tems = input.substring(i + 1);
			if (isVowel(chrOne) && !bVowel)// 检查是否母音 而且不是
			{
				bVowel = true;
				nPositionIndex++;
				mapVowelPosition.put(nPositionIndex, i);
				mapConsCount.put(nPositionIndex, iConsCount);//保存上次母音到现在下个母音直接的辅音或者其他字符数量
				blnFChCons = false;
				iConsCount = 0;
				if (nPositionIndex > 1) {//跳过词的第一个字符
					int iDistance = mapVowelPosition.get(nPositionIndex)- mapVowelPosition.get(nPositionIndex - 1);//两个母音的距离
					if (iDistance > 0 && iDistance < 5) {//如果字符长度大于0并且小于5（最多也两个母音和两个辅音组成一个音节的情况为主）
						result.add(remainword.substring(0,iDistance+ mapConsCount.get(nPositionIndex-1)-1));
						remainword = remainword.substring(iDistance+mapConsCount.get(nPositionIndex - 1) - 1);
						mapConsCount.put(nPositionIndex,mapConsCount.get(nPositionIndex)-(iDistance - 2));
					} else {
						result.add(remainword.substring(0,iDistance+mapConsCount.get(nPositionIndex - 1)-2));
						remainword = remainword.substring(iDistance+ mapConsCount.get(nPositionIndex - 1) - 2);
						mapConsCount.put(nPositionIndex,mapConsCount.get(nPositionIndex)- (iDistance - 3));
					}
				}
			} else//不是母音
			{
				if (blnFChCons) {
					iConsCount++;
				} else {
					iConsCount = 1;
				}
				blnFChCons = true;
				bVowel = false;
			}
		}
		result.add(remainword);
		return result;
	}

	/**
	 * 判断字符是不是8个母音之间的一个
	 * @param c 字符
	 * @return 如果母音返回true 否则返回false
	 */
	private boolean isVowel(char c) {
		if ((((c != 0x649) && (c != 0x6d0)))&&((c != 0x627) && (c != 0x648))
				&& (((c != 0x6d5) && (c != 0x6c6)) && ((c != 0x6c7) && (c != 0x6c8)))) {
			return false;
		}
		return true;
	}

}
