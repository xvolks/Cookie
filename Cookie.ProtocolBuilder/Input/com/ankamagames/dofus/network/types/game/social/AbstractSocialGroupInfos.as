package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class AbstractSocialGroupInfos implements INetworkType
   {
      
      public static const protocolId:uint = 416;
       
      
      public function AbstractSocialGroupInfos()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 416;
      }
      
      public function initAbstractSocialGroupInfos() : AbstractSocialGroupInfos
      {
         return this;
      }
      
      public function reset() : void
      {
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
      }
      
      public function serializeAs_AbstractSocialGroupInfos(param1:ICustomDataOutput) : void
      {
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAs_AbstractSocialGroupInfos(param1:ICustomDataInput) : void
      {
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
      }
      
      public function deserializeAsyncAs_AbstractSocialGroupInfos(param1:FuncTree) : void
      {
      }
   }
}
