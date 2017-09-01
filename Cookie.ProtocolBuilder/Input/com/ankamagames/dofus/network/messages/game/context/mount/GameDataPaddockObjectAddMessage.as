package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.dofus.network.types.game.paddock.PaddockItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameDataPaddockObjectAddMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5990;
       
      
      private var _isInitialized:Boolean = false;
      
      public var paddockItemDescription:PaddockItem;
      
      private var _paddockItemDescriptiontree:FuncTree;
      
      public function GameDataPaddockObjectAddMessage()
      {
         this.paddockItemDescription = new PaddockItem();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5990;
      }
      
      public function initGameDataPaddockObjectAddMessage(param1:PaddockItem = null) : GameDataPaddockObjectAddMessage
      {
         this.paddockItemDescription = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.paddockItemDescription = new PaddockItem();
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
         this.serializeAs_GameDataPaddockObjectAddMessage(param1);
      }
      
      public function serializeAs_GameDataPaddockObjectAddMessage(param1:ICustomDataOutput) : void
      {
         this.paddockItemDescription.serializeAs_PaddockItem(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameDataPaddockObjectAddMessage(param1);
      }
      
      public function deserializeAs_GameDataPaddockObjectAddMessage(param1:ICustomDataInput) : void
      {
         this.paddockItemDescription = new PaddockItem();
         this.paddockItemDescription.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameDataPaddockObjectAddMessage(param1);
      }
      
      public function deserializeAsyncAs_GameDataPaddockObjectAddMessage(param1:FuncTree) : void
      {
         this._paddockItemDescriptiontree = param1.addChild(this._paddockItemDescriptiontreeFunc);
      }
      
      private function _paddockItemDescriptiontreeFunc(param1:ICustomDataInput) : void
      {
         this.paddockItemDescription = new PaddockItem();
         this.paddockItemDescription.deserializeAsync(this._paddockItemDescriptiontree);
      }
   }
}
