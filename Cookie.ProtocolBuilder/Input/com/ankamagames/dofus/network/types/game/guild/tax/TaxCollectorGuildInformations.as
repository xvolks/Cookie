package com.ankamagames.dofus.network.types.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TaxCollectorGuildInformations extends TaxCollectorComplementaryInformations implements INetworkType
   {
      
      public static const protocolId:uint = 446;
       
      
      public var guild:BasicGuildInformations;
      
      private var _guildtree:FuncTree;
      
      public function TaxCollectorGuildInformations()
      {
         this.guild = new BasicGuildInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 446;
      }
      
      public function initTaxCollectorGuildInformations(param1:BasicGuildInformations = null) : TaxCollectorGuildInformations
      {
         this.guild = param1;
         return this;
      }
      
      override public function reset() : void
      {
         this.guild = new BasicGuildInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorGuildInformations(param1);
      }
      
      public function serializeAs_TaxCollectorGuildInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_TaxCollectorComplementaryInformations(param1);
         this.guild.serializeAs_BasicGuildInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorGuildInformations(param1);
      }
      
      public function deserializeAs_TaxCollectorGuildInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.guild = new BasicGuildInformations();
         this.guild.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorGuildInformations(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorGuildInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._guildtree = param1.addChild(this._guildtreeFunc);
      }
      
      private function _guildtreeFunc(param1:ICustomDataInput) : void
      {
         this.guild = new BasicGuildInformations();
         this.guild.deserializeAsync(this._guildtree);
      }
   }
}
