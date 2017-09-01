package com.ankamagames.dofus.network.messages.game.context
{
   import com.ankamagames.dofus.network.types.game.context.IdentifiedEntityDispositionInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameEntityDispositionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5693;
       
      
      private var _isInitialized:Boolean = false;
      
      public var disposition:IdentifiedEntityDispositionInformations;
      
      private var _dispositiontree:FuncTree;
      
      public function GameEntityDispositionMessage()
      {
         this.disposition = new IdentifiedEntityDispositionInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5693;
      }
      
      public function initGameEntityDispositionMessage(param1:IdentifiedEntityDispositionInformations = null) : GameEntityDispositionMessage
      {
         this.disposition = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.disposition = new IdentifiedEntityDispositionInformations();
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
         this.serializeAs_GameEntityDispositionMessage(param1);
      }
      
      public function serializeAs_GameEntityDispositionMessage(param1:ICustomDataOutput) : void
      {
         this.disposition.serializeAs_IdentifiedEntityDispositionInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameEntityDispositionMessage(param1);
      }
      
      public function deserializeAs_GameEntityDispositionMessage(param1:ICustomDataInput) : void
      {
         this.disposition = new IdentifiedEntityDispositionInformations();
         this.disposition.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameEntityDispositionMessage(param1);
      }
      
      public function deserializeAsyncAs_GameEntityDispositionMessage(param1:FuncTree) : void
      {
         this._dispositiontree = param1.addChild(this._dispositiontreeFunc);
      }
      
      private function _dispositiontreeFunc(param1:ICustomDataInput) : void
      {
         this.disposition = new IdentifiedEntityDispositionInformations();
         this.disposition.deserializeAsync(this._dispositiontree);
      }
   }
}
