package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightResultTaxCollectorListEntry extends FightResultFighterListEntry implements INetworkType
   {
      
      public static const protocolId:uint = 84;
       
      
      public var level:uint = 0;
      
      public var guildInfo:BasicGuildInformations;
      
      public var experienceForGuild:int = 0;
      
      private var _guildInfotree:FuncTree;
      
      public function FightResultTaxCollectorListEntry()
      {
         this.guildInfo = new BasicGuildInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 84;
      }
      
      public function initFightResultTaxCollectorListEntry(param1:uint = 0, param2:uint = 0, param3:FightLoot = null, param4:Number = 0, param5:Boolean = false, param6:uint = 0, param7:BasicGuildInformations = null, param8:int = 0) : FightResultTaxCollectorListEntry
      {
         super.initFightResultFighterListEntry(param1,param2,param3,param4,param5);
         this.level = param6;
         this.guildInfo = param7;
         this.experienceForGuild = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.level = 0;
         this.guildInfo = new BasicGuildInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightResultTaxCollectorListEntry(param1);
      }
      
      public function serializeAs_FightResultTaxCollectorListEntry(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightResultFighterListEntry(param1);
         if(this.level < 1 || this.level > 200)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
         this.guildInfo.serializeAs_BasicGuildInformations(param1);
         param1.writeInt(this.experienceForGuild);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightResultTaxCollectorListEntry(param1);
      }
      
      public function deserializeAs_FightResultTaxCollectorListEntry(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._levelFunc(param1);
         this.guildInfo = new BasicGuildInformations();
         this.guildInfo.deserialize(param1);
         this._experienceForGuildFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightResultTaxCollectorListEntry(param1);
      }
      
      public function deserializeAsyncAs_FightResultTaxCollectorListEntry(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._levelFunc);
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
         param1.addChild(this._experienceForGuildFunc);
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 1 || this.level > 200)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of FightResultTaxCollectorListEntry.level.");
         }
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new BasicGuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
      
      private function _experienceForGuildFunc(param1:ICustomDataInput) : void
      {
         this.experienceForGuild = param1.readInt();
      }
   }
}
