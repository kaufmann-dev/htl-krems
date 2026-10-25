<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">

    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <groups>
            <xsl:apply-templates select="//groups/group"></xsl:apply-templates>
        </groups>
    </xsl:template>

    <xsl:template match="//groups/group">
        <group>
            <xsl:attribute name="id">
                <xsl:value-of select="@id"></xsl:value-of>
            </xsl:attribute>
            <xsl:apply-templates select="./team"></xsl:apply-templates>
            <xsl:for-each select="./team">
                <xsl:variable name="code">
                    <xsl:value-of select="./text()"></xsl:value-of>
                </xsl:variable>
                <team>
                    <xsl:attribute name="goalkeeper">
                        <xsl:value-of select="//teams/team/nation[./FIFA-code = $code]/FIFA-code"></xsl:value-of>
                    </xsl:attribute>
                    <xsl:attribute name="defense">
                        <xsl:value-of select="count(//teams/team[./nation/FIFA-code = $code]/position[@type = 'defense']/player)"></xsl:value-of>
                    </xsl:attribute>
                    <xsl:attribute name="midfield">
                        <xsl:value-of select="count(//teams/team[./nation/FIFA-code = $code]/position[@type = 'midfield']/player)"></xsl:value-of>
                    </xsl:attribute>
                    <xsl:attribute name="attack">
                        <xsl:value-of select="count(//teams/team[./nation/FIFA-code = $code]/position[@type = 'attack']/player)"></xsl:value-of>
                    </xsl:attribute>
                    <xsl:value-of select="$code"></xsl:value-of>
                </team>
            </xsl:for-each>
        </group>
    </xsl:template>

    <xsl:template match="team">
        <match>
            <xsl:apply-templates
        </match>
    </xsl:template>

</xsl:stylesheet>