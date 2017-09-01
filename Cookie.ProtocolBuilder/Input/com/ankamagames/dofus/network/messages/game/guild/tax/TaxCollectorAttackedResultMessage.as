package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorBasicInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TaxCollectorAttackedResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5635;
       
      
      private var _isInitialized:Boolean = false;
      
      public var deadOrAlive:Boolean = false;
      
      public var basicInfos:TaxCollectorBasicInformations;
      
      public var guild:BasicGuildInformations;
      
      private var _basicInfostree:FuncTree;
      
      private var _guildtree:FuncTree;
      
      public function TaxCollectorAttackedResultMessage()
      {
         this.basicInfos = new TaxCollectorBasicInformations();
         this.guild = new BasicGuildInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5635;
      }
      
      public function initTaxCollectorAttackedResultMessage(param1:Boolean = false, param2:TaxCollectorBasicInformations = null, param3:BasicGuildInformations = null) : TaxCollectorAttackedResultMessage
      {
         this.deadOrAlive = param1;
         this.basicInfos = param2;
         this.guild = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.deadOrAlive = false;
         this.basicInfos = new TaxCollectorBasicInformations();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorAttackedResultMessage(param1);
      }
      
      public function serializeAs_TaxCollectorAttackedResultMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.deadOrAlive);
         this.basicInfos.serializeAs_TaxCollectorBasicInformations(param1);
         this.guild.serializeAs_BasicGuildInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorAttackedResultMessage(param1);
      }
      
      public function deserializeAs_TaxCollectorAttackedResultMessage(param1:ICustomDataInput) : void
      {
         this._deadOrAliveFunc(param1);
         this.basicInfos = new TaxCollectorBasicInformations();
         this.basicInfos.deserialize(param1);
         this.guild = new BasicGuildInformations();
         this.guild.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorAttackedResultMessage(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorAttackedResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._deadOrAliveFunc);
         this._basicInfostree = param1.addChild(this._basicInfostreeFunc);
         this._guildtree = param1.addChild(this._guildtreeFunc);
      }
      
      private function _deadOrAliveFunc(param1:ICustomDataInput) : void
      {
         this.deadOrAlive = param1.readBoolean();
      }
      
      private function _basicInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.basicInfos = new TaxCollectorBasicInformations();
         this.basicInfos.deserializeAsync(this._basicInfostree);
      }
      
      private function _guildtreeFunc(param1:ICustomDataInput) : void
      {
         this.guild = new BasicGuildInformations();
         this.guild.deserializeAsync(this._guildtree);
      }
   }
}
