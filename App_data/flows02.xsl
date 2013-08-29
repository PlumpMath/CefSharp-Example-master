<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="field-list">
		<p><u><xsl:value-of select="."/></u></p>
	</xsl:template>
	
	<xsl:template match="field-list">
		<p><b>
		
    <xsl:value-of select="//@value"/>
		
  <table border="1">
    <tr bgcolor="#9acd32">
      <th>left</th>
      <th>right</th>
    </tr>
    <xsl:for-each select="field">
    <tr>
     <td><xsl:value-of select="@name"/></td>
      <td><xsl:value-of select="@value"/></td>
    </tr>
    </xsl:for-each>
  </table>
  
		<xsl:value-of select="."/>
		</b></p>
	</xsl:template>
	<xsl:template match="/">
		<html>
		<body>
		<xsl:apply-templates/>
		</body>
		</html>
	</xsl:template>
	
</xsl:stylesheet>