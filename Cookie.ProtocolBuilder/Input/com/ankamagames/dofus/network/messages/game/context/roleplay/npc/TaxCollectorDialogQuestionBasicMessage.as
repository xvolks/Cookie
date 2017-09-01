package com.ankamagames.dofus.network.messages.game.context.roleplay.npc
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TaxCollectorDialogQuestionBasicMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5619;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guildInfo:BasicGuildInformations;
      
      private var _guildInfotree:FuncTree;
      
      public function TaxCollectorDialogQuestionBasicMessage()
      {
         this.guildInfo = new BasicGuildInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5619;
      }
      
      public function initTaxCollectorDialogQuestionBasicMessage(param1:BasicGuildInformations = null) : TaxCollectorDialogQuestionBasicMessage
      {
         this.guildInfo = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guildInfo = new BasicGuildInformations();
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
         this.serializeAs_TaxCollectorDialogQuestionBasicMessage(param1);
      }
      
      public function serializeAs_TaxCollectorDialogQuestionBasicMessage(param1:ICustomDataOutput) : void
      {
         this.guildInfo.serializeAs_BasicGuildInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorDialogQuestionBasicMessage(param1);
      }
      
      public function deserializeAs_TaxCollectorDialogQuestionBasicMessage(param1:ICustomDataInput) : void
      {
         this.guildInfo = new BasicGuildInformations();
         this.guildInfo.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorDialogQuestionBasicMessage(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorDialogQuestionBasicMessage(param1:FuncTree) : void
      {
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new BasicGuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
   }
}
