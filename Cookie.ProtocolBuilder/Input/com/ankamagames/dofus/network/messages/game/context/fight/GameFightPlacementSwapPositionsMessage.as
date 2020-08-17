package com.ankamagames.dofus.network.messages.game.context.fight
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
   public class GameFightPlacementSwapPositionsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6544;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dispositions:Vector.<IdentifiedEntityDispositionInformations>;
      
      private var _dispositionstree:FuncTree;
      
      private var _dispositionsindex:uint = 0;
      
      public function GameFightPlacementSwapPositionsMessage()
      {
         this.dispositions = new Vector.<IdentifiedEntityDispositionInformations>(2,true);
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6544;
      }
      
      public function initGameFightPlacementSwapPositionsMessage(param1:Vector.<IdentifiedEntityDispositionInformations> = null) : GameFightPlacementSwapPositionsMessage
      {
         this.dispositions = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dispositions = new Vector.<IdentifiedEntityDispositionInformations>(2,true);
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
         this.serializeAs_GameFightPlacementSwapPositionsMessage(param1);
      }
      
      public function serializeAs_GameFightPlacementSwapPositionsMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this.dispositions[_loc2_].serializeAs_IdentifiedEntityDispositionInformations(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightPlacementSwapPositionsMessage(param1);
      }
      
      public function deserializeAs_GameFightPlacementSwapPositionsMessage(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this.dispositions[_loc2_] = new IdentifiedEntityDispositionInformations();
            this.dispositions[_loc2_].deserialize(param1);
            _loc2_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightPlacementSwapPositionsMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightPlacementSwapPositionsMessage(param1:FuncTree) : void
      {
         this._dispositionstree = param1.addChild(this._dispositionstreeFunc);
      }
      
      private function _dispositionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this._dispositionstree.addChild(this._dispositionsFunc);
            _loc2_++;
         }
      }
      
      private function _dispositionsFunc(param1:ICustomDataInput) : void
      {
         this.dispositions[this._dispositionsindex] = new IdentifiedEntityDispositionInformations();
         this.dispositions[this._dispositionsindex].deserializeAsync(this._dispositionstree.children[this._dispositionsindex]);
         this._dispositionsindex++;
      }
   }
}
